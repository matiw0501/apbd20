using apbdKolos2ProbnyTest.Database;
using apbdKolos2ProbnyTest.DTOs;
using apbdKolos2ProbnyTest.Exceptions;
using apbdKolos2ProbnyTest.Models;
using Microsoft.EntityFrameworkCore;

namespace apbdKolos2ProbnyTest.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<ReturnCharacterDTO> GetCharacter(int characterId)
    {
        var character = await _context.Characters.Where(b => b.CharacterId == characterId)
            .Select(e => new ReturnCharacterDTO
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                CurrentWeight = e.CurrentWeight,
                MaxWeight = e.MaxWeight,
                ItemDtos = e.Backpacks.Select(b => new ItemDTO()
                {
                    ItemName = b.Item.Name,
                    ItemWeight = b.Item.Weight,
                    Amount = b.Amount,
                }).ToList(),
                TitileDtos = e.CharacterTitles.Select(c => new TitileDTO()
                {
                    Titile = c.Title.Name,
                    AquiredAt = c.AcquiredAt
                }).ToList(),
            }).FirstOrDefaultAsync();

        if (character is null)
        {
            throw new NotFoundException("No character found");
        }

        return character;
    }

    public async Task AddEq(int characterId, ListDTO listDTO)
    {
        
        var itemIds = listDTO.Ints.Select(e=>e.ItemId).ToList();
        var itemIdsCompared = await _context.Items.Where(it => itemIds.Contains(it.ItemId)).ToListAsync();
        if (itemIds.Count != itemIdsCompared.Count)
        {
            throw new NotFoundException("No item or items were found");
        }

        var character = await _context.Characters
            .Include(c => c.Backpacks)
            .ThenInclude(b=> b.Item)
            .FirstOrDefaultAsync(c => c.CharacterId == characterId);
        
        
        int aktualnaWaga = character.CurrentWeight;
        int nowaWaga = listDTO.Ints.Sum(i => itemIdsCompared.First(it => it.ItemId == i.ItemId).Weight * i.Amount);

        if (nowaWaga + aktualnaWaga > character.MaxWeight)
        {
            throw new ConflictException("New weight is too big for character");
        }

        await using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            foreach (var ints in listDTO.Ints)
            {
                var backpackItem = await _context.Backpacks.FirstOrDefaultAsync(b => b.ItemId == ints.ItemId && b.CharacterdId == characterId);
                if (backpackItem !=null )
                {
                    backpackItem.Amount += ints.Amount;
                    _context.Backpacks.Update(backpackItem);
                }
                else
                {
                    var newItem = new Backpack
                    {
                        ItemId = ints.ItemId,
                        CharacterdId = characterId,
                        Amount = ints.Amount,
                    };
                    _context.Backpacks.Add(newItem);
                }
            }
            character.CurrentWeight += nowaWaga;
            _context.Characters.Update(character);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            throw;
        }




    }

}
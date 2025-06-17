using apbdKolos2ProbnyTest.DTOs;

namespace apbdKolos2ProbnyTest.Database;

public interface IDbService
{
    public Task<ReturnCharacterDTO> GetCharacter(int characterId);
    public Task AddEq(int characterId, ListDTO listDTO);
}
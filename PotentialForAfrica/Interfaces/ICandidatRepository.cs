using PotentialForAfrica.Models;

namespace PotentialForAfrica.Interfaces
{
    public interface ICandidatRepository
    {
        Task<bool> AjouterCandidat(CandidatModel Candidat);
        Task<List<CandidatModel>> RecupererCandidatsAsync(int OffreId = 0);
        Task<CandidatModel> RecupererCandidatsAsyncById(int CandidatId);
        Task<bool> RemoveCandidatsAsync(CandidatModel Candidat);

    }
}

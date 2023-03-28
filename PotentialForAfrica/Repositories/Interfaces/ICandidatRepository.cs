using PotentialForAfrica.Models;

namespace PotentialForAfrica.Repositories.Interfaces
{
    public interface ICandidatRepository
    {
         Task<bool> AjouterCandidat(CandidatModel Candidat);
        Task<List<CandidatModel>> RecupererCandidatsAsync(int OffreId = 0);
    }
}

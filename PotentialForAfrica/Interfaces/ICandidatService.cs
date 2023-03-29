using PotentialForAfrica.Models;

namespace PotentialForAfrica.Interfaces
{
    public interface ICandidatService
    {
        Task<bool> AjouterCandidat(CandidatModel Candidat);
        Task<List<CandidatModel>> RecupererCandidatsAsync(int OffreId = 0);
        Task<string> UploadCV(IFormFile FileCv, string NomCandidat,string PrenomCandidat);
        Task<CandidatModel> RecupererCandidatsAsyncById(int CandidatId );
        Task<bool> RemoveCandidatsAsync(CandidatModel Candidat);

    }
}

using PotentialForAfrica.Models;

namespace PotentialForAfrica.Interfaces
{
    public interface ICandidatService
    {
        Task<bool> AjouterCandidat(CandidatModel Candidat);
        Task<List<CandidatModel>> RecupererCandidatsAsync(int OffreId = 0);
        Task<bool> UploadCV(IFormFile FileCv, string NomRepertoire);

    }
}

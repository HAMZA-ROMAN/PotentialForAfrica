using PotentialForAfrica.Data;
using PotentialForAfrica.Exception;
using PotentialForAfrica.Interfaces;
using PotentialForAfrica.Models;

namespace PotentialForAfrica.Services
{
    public class CandidatService : ICandidatService
    {
        private readonly ICandidatRepository _candidatDb;
        private readonly ILogger<ICandidatService> _logger;
        public CandidatService(ICandidatRepository CandidatDb, ILogger<ICandidatService> logger)
        {
            _candidatDb = CandidatDb;
            _logger = logger;
        }
        public async Task<bool> AjouterCandidat(CandidatModel Candidat)
        {
            try
            {
                return await _candidatDb.AjouterCandidat(Candidat);         
            }
            catch (System.Exception Excep)
            {
                throw new CandidatServiceException($"Erreur dans l'ajout de la candidature {Excep.Message}", innerException: Excep.InnerException);
            }
        }

        public Task<List<CandidatModel>> RecupererCandidatsAsync(int OffreId = 0)
        {
            try
            {
                return _candidatDb.RecupererCandidatsAsync();
            }
            catch (System.Exception Excep)
            {
                throw new CandidatServiceException($"Erreur dans la récupération des candidatures {Excep.Message}", innerException: Excep.InnerException);
            }
        }
        public async Task<bool> UploadCV(IFormFile FileCv,string NomRepertoire)
        {
            string path ;
            try
            {
                _logger.LogTrace($"Début d'upload de CV {FileCv.Name}");
                if (FileCv.Length > 0)
                {
                    path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedCV", NomRepertoire)) ;
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (var fileStream = new FileStream(Path.Combine(path, FileCv.FileName), FileMode.Create))
                    {
                        await FileCv.CopyToAsync(fileStream);
                    }        
                }
                _logger.LogTrace($"Fin upload");
                return true;
            }
            catch (System.Exception Excep)
            {
                throw new CandidatServiceException($"Erreur dans l'upload de CV de candidature {Excep.Message}", innerException: Excep.InnerException);
            }
        }
    }
}

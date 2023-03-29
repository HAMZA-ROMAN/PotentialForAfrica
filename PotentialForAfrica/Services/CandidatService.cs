using PotentialForAfrica.Data;
using PotentialForAfrica.Exception;
using PotentialForAfrica.Interfaces;
using PotentialForAfrica.Models;
using System.IO;
using static System.Net.WebRequestMethods;
using File = System.IO.File;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace PotentialForAfrica.Services
{
    public class CandidatService : ICandidatService
    {
        private readonly ICandidatRepository _candidatDb;
        private readonly ILogger<ICandidatService> _logger;
        private IHostingEnvironment _environment;
        public CandidatService(ICandidatRepository CandidatDb, ILogger<ICandidatService> logger, IHostingEnvironment Environment)
        {
            _candidatDb = CandidatDb;
            _logger = logger;
            _environment = Environment;
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

        public async Task<CandidatModel> RecupererCandidatsAsyncById(int CandidatId)
        {
            try
            {
                return await _candidatDb.RecupererCandidatsAsyncById(CandidatId);
            }
            catch (System.Exception Excep)
            {
                throw new CandidatServiceException($"Erreur dans la récupération de candidatures {Excep.Message}", innerException: Excep.InnerException);
            }
        }

        public async Task<bool> RemoveCandidatsAsync(CandidatModel Candidat)
        {
            if (Candidat is null)
                throw new System.Exception("paramétre est vide");
            try
            {
                await _candidatDb.RemoveCandidatsAsync(Candidat);
                if (!string.IsNullOrWhiteSpace(Candidat.CVPath))
                {
                    _logger.LogTrace($"Début de suppression de CV {Candidat.CVPath}");
                    string FullPathCV = Path.Combine(Environment.CurrentDirectory, @"wwwroot", Candidat.CVPath);
                    //supprimer le cv 
                    File.Delete(FullPathCV);
                   // supprimer le dossier de candidat
                    Directory.GetParent(FullPathCV)?.Delete();
                    _logger.LogTrace($"Fin de suppression de CV {Candidat.CVPath}");
                }
                return true;
            }
            catch (System.Exception Excep)
            {
                throw new CandidatServiceException($"Erreur dans la suppression de candidature ID {Candidat.CandidatId}, {Excep.Message}", innerException: Excep.InnerException);

            }
        }

        public async Task<string> UploadCV(IFormFile FileCv, string NomCandidat, string PrenomCandidat)
        {
            string CandidatCVPath = string.Empty;
            try
            {
                _logger.LogTrace($"Début d'upload de CV {FileCv.Name}");
                if (FileCv is not null && FileCv.Length > 0)
                {
                    string RootPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"wwwroot\UploadedCV"));
                    if (!Directory.Exists(RootPath))
                    {
                        Directory.CreateDirectory(RootPath);
                    }
                    CandidatCVPath = Path.Combine(CreateCandidatFolder(RootPath, NomCandidat, PrenomCandidat), FileCv.FileName);
                    using (var fileStream = new FileStream(Path.Combine(RootPath, CandidatCVPath), FileMode.Create))
                    {
                        await FileCv.CopyToAsync(fileStream);
                    }
                }
                _logger.LogTrace($"Fin upload");
                return Path.Combine("UploadedCV", CandidatCVPath);
            }
            catch (System.Exception Excep)
            {
                throw new CandidatServiceException($"Erreur dans l'upload de CV de candidature {Excep.Message}", innerException: Excep.InnerException);
            }
        }
        private string CreateCandidatFolder(string RootPath, string NomCandidat, string PrenomCandidat)
        {
            try
            {
                _logger.LogTrace($"Début de création de dossier de Candidat {NomCandidat}_{PrenomCandidat}");
                string FolderName = $"{NomCandidat}_{PrenomCandidat}";
                string Fullpath = Path.GetFullPath(Path.Combine(RootPath, FolderName));
                int FolderIndice = 0;
                //peut étre on tombe dans des condidats portent le meme nom et prénom 
                while (Directory.Exists(Fullpath))
                {
                    _logger.LogTrace($"le dossier {FolderName} existe déja");

                    FolderName = $"{NomCandidat}_{PrenomCandidat}_{++FolderIndice}";
                    Fullpath = Path.GetFullPath(Path.Combine(RootPath, FolderName));
                }
                Directory.CreateDirectory(Fullpath);
                _logger.LogTrace($"fin création de dossier :{FolderName}");
                return FolderName;
            }
            catch (System.Exception Excep)
            {
                throw new CandidatServiceException($"Erreur dans la création de dossier de candidat {Excep.Message}", innerException: Excep.InnerException);
            }
        }

    }
}

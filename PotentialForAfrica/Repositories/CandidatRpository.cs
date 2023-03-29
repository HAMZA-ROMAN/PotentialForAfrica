using Microsoft.EntityFrameworkCore;
using PotentialForAfrica.Data;
using PotentialForAfrica.Exception;
using PotentialForAfrica.Interfaces;
using PotentialForAfrica.Models;

namespace PotentialForAfrica.Repositories
{
    public class CandidatRpository : ICandidatRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ICandidatRepository> _logger;
        public CandidatRpository(ApplicationDbContext context, ILogger<ICandidatRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<bool> AjouterCandidat(CandidatModel Candidat)
        {
            try
            {
                _logger.LogTrace($"Début d'insertion de la candidatures {Candidat.Nom}_{Candidat.Prenom}");
                _context.Add(Candidat);
                await _context.SaveChangesAsync();
                _logger.LogTrace($"Fin d'insertion de la candidatures {Candidat.Nom}_{Candidat.Prenom}");
                return true;
            }
            catch (IOException Excep)
            {
                throw new CandidatException($"Erreur dans l'ajout de la candidature {Excep.Message}", innerException: Excep.InnerException);
            }
          
        }

        public async Task<List<CandidatModel>> RecupererCandidatsAsync(int OffreId = 0)
        {
            try
            {
                _logger.LogTrace($"Début de la récupération des candidatures pour l'offre {OffreId}");
                List<CandidatModel> candidats =  await _context.Candidats.ToListAsync();
                _logger.LogTrace($"Fin de la récupération des candidatures pour l'offre {OffreId}");
                _logger.LogTrace($"Nombre des candidat  {candidats.Count}");

                return candidats;
            }
            catch (IOException Excep)
            {
                throw new CandidatException($"Erreur dans la récupération des candidatures {Excep.Message}", innerException: Excep.InnerException);
            }
        }
        public async Task<CandidatModel> RecupererCandidatsAsyncById(int CandidatId)
        {
            try
            {
                _logger.LogTrace($"Début de la récupération de candidature ID = {CandidatId}");
                 CandidatModel candidat = await _context.Candidats.FirstOrDefaultAsync(c =>c.CandidatId ==CandidatId);
                _logger.LogTrace($"Fin de la récupération");
                return candidat;
            }
            catch (IOException Excep)
            {
                throw new CandidatException($"Erreur dans la récupération des candidatures {Excep.Message}", innerException: Excep.InnerException);
            }
        }

        public async Task<bool> RemoveCandidatsAsync(CandidatModel Candidat)
        {
            try
            {
                _logger.LogTrace($"Début de la suppression de candidature ID = {Candidat.CandidatId}");
                _context.Candidats.Remove(Candidat);
                await _context.SaveChangesAsync();
                _logger.LogTrace($"Fin de la suppression de candidature ID = {Candidat.CandidatId}");

                return true;
            }
            catch (System.Exception Excep)
            {
                throw new CandidatException($"Erreur dans la suppression  dcandidature ID= {Candidat.CandidatId}, {Excep.Message}", innerException: Excep.InnerException);
            }
        }
    }
}

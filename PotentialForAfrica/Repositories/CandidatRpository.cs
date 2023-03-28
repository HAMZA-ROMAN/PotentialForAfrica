using Microsoft.EntityFrameworkCore;
using PotentialForAfrica.Data;
using PotentialForAfrica.Exception;
using PotentialForAfrica.Models;
using PotentialForAfrica.Repositories.Interfaces;

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
    }
}

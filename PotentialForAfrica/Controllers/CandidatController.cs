using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PotentialForAfrica.Data;
using PotentialForAfrica.Helpers;
using PotentialForAfrica.Interfaces;
using PotentialForAfrica.Models;
using IEmailSender = PotentialForAfrica.Interfaces.IEmailSender;

namespace PotentialForAfrica.Controllers
{
    public class CandidatController : Controller
    {
        private readonly ICandidatService mCandidatService;
        private readonly IEmailSender mMailSenderService;
        public CandidatController(ICandidatService pCandidatService, IEmailSender emailSender)
        {
            mCandidatService = pCandidatService;
            mMailSenderService = emailSender;
        }

        // GET: Candidat
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await mCandidatService.RecupererCandidatsAsync());
        }
      
        //  GET: Candidat/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Candidat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CandidatModel candidatModel,IFormFile FileCV)
        {
            if (ModelState.IsValid)
            {
                candidatModel.CVPath = await mCandidatService.UploadCV(FileCV, candidatModel.Nom, candidatModel.Prenom);
                if ( string.IsNullOrWhiteSpace(candidatModel.CVPath))
                {
                    ViewBag.message = "upload de CV est echoué,essayez de nouveau";
                    return View(candidatModel);
                }
                await mCandidatService.AjouterCandidat(candidatModel);
                var message = new Message($"{candidatModel.Nom} {candidatModel.Prenom}",candidatModel.Mail, "Votre Candidature", $"Bonjour {candidatModel.Nom} {candidatModel.Prenom}, vous avez postulé avec succès pour l'offre développeur dotnet");

                // mMailSenderService.SendEmail(message);
                return RedirectToAction(nameof(Create));
            }
            return View(candidatModel);
        }

        // GET: Candidat/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var candidatModel = await mCandidatService.RecupererCandidatsAsyncById(id);
            if (candidatModel == null)
            {
                return NotFound();
            }
            return View(candidatModel);
        }

        // POST: Candidat/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int CandidatId)
        {
            var candidatModel = await mCandidatService.RecupererCandidatsAsyncById(CandidatId);
            if (candidatModel != null)
            {
                await mCandidatService.RemoveCandidatsAsync(candidatModel);
            }
            ViewBag.message = "suppression impossible,Erreur au nivaeu de serveur";
            return RedirectToAction(nameof(Index));
        }

    }
}

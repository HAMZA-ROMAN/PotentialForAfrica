using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PotentialForAfrica.Data;
using PotentialForAfrica.Models;
using PotentialForAfrica.Repositories.Interfaces;

namespace PotentialForAfrica.Controllers
{
    public class CandidatController : Controller
    {
        private readonly ICandidatRepository mCandidatRepository;

        public CandidatController(ICandidatRepository pCandidatRepository)
        {
            mCandidatRepository = pCandidatRepository;
        }

       // GET: Candidat
        public async Task<IActionResult> Index()
        {
            return View(await mCandidatRepository.RecupererCandidatsAsync());
        }

      //  GET: Candidat/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.Candidats == null)
        //    {
        //        return NotFound();
        //    }

        //    var candidatModel = await _context.Candidats
        //        .FirstOrDefaultAsync(m => m.CandidatId == id);
        //    if (candidatModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(candidatModel);
        //}

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
        public async Task<IActionResult> Create(CandidatModel candidatModel)
        {
            if (ModelState.IsValid)
            {
                await mCandidatRepository.AjouterCandidat(candidatModel);
                return RedirectToAction(nameof(Index));
            }
            return View(candidatModel);
        }

        // GET: Candidat/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Candidats == null)
        //    {
        //        return NotFound();
        //    }

        //    var candidatModel = await _context.Candidats.FindAsync(id);
        //    if (candidatModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(candidatModel);
        //}

        // POST: Candidat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("CandidatId,Nom,Prenom,Mail,Telehone,NiveauEtude,NbreAnneeExperience,DernierEmployeur,NomCV")] CandidatModel candidatModel)
        //{
        //    if (id != candidatModel.CandidatId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(candidatModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CandidatModelExists(candidatModel.CandidatId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(candidatModel);
        //}

        //// GET: Candidat/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.Candidats == null)
        //    {
        //        return NotFound();
        //    }

        //    var candidatModel = await _context.Candidats
        //        .FirstOrDefaultAsync(m => m.CandidatId == id);
        //    if (candidatModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(candidatModel);
        //}

        //// POST: Candidat/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Candidats == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.Candidats'  is null.");
        //    }
        //    var candidatModel = await _context.Candidats.FindAsync(id);
        //    if (candidatModel != null)
        //    {
        //        _context.Candidats.Remove(candidatModel);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CandidatModelExists(int id)
        //{
        //  return (_context.Candidats?.Any(e => e.CandidatId == id)).GetValueOrDefault();
        //}
    }
}

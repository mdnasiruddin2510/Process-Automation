
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Domain;
using Application.Interfaces;
using App.Domain.Interface.Service;
using Data.Context;
using ProcessAutomation.Models;


namespace ERPConfiguration.Controllers 
{
    public class LanguageController : Controller
    {
        private readonly IPhrasesAppServices _phraseService;
        private readonly IDictionaryAppService _dictionaryService;
       
        public LanguageController(IPhrasesAppServices _phraseService,
                                        IDictionaryAppService _dictionaryService)
        {
            this._phraseService = _phraseService;
            this._dictionaryService = _dictionaryService;
          
        }
        // GET: Language
        public ActionResult Language()
        {
            ViewBag.LangName = LoadDropDown.LoadLanguage();
            return View();
        }

        public ActionResult GetSeletedLanguage(int LangId)
        {

            try
            {
                List<Phrases> Phrase = _phraseService.All().ToList();
                // List<Phrases> Phrase = _phraseService.All().ToList();

                #region Updating language data
                foreach (var item in Phrase)
                {
                    var dicLanguage = _dictionaryService.All().Where(a => a.LangId == LangId && a.PhraseId == item.PhraseId).FirstOrDefault();

                    item.Phrase = dicLanguage.Phrase;
                    _phraseService.Update(item);
                }
                _phraseService.Save();


                #endregion

                return Json(Phrase.Select(s => s.Phrase).ToList(), JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("0", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetAllPhrases(int Id)
        {
            string sql = string.Format("exec GetPhrases '" + Id + "'");

            try
            {
                using (ERPConfigurationContext dbContext = new ERPConfigurationContext())
                {
                    var phrases = dbContext.Database.SqlQuery<Phrases>(sql).Select(x => x.Phrase).ToList();

                    if (phrases != null)
                    {
                        return Json(phrases, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json("0", JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception)
            {
                return Json("0", JsonRequestBehavior.AllowGet);
            }
        }
    }
}
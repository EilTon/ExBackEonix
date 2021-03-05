using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ex2.DAL;
using Ex2.Models;
using PagedList;

namespace Ex2.Controllers
{
    public class PersonController : Controller
    {
        private PersonContext db = new PersonContext();

        // GET: Person
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var persons = from s in db.Persons
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
				persons = persons.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
					persons = persons.OrderByDescending(s => s.LastName);
                    break;
                default:  // Name ascending 
					persons = persons.OrderBy(s => s.LastName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(persons.ToPagedList(pageNumber, pageSize));
        }

		#region Create
		// GET: Person/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Person/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "FirstName, LastName")] Person person)
		{
			try
			{
				if (ModelState.IsValid)
				{
					db.Persons.Add(person);
					db.SaveChanges();
					return RedirectToAction("Index");
				}
			}
			catch (RetryLimitExceededException /* dex */)
			{
				//Log the error (uncomment dex variable name and add a line here to write a log.
				ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
			}
			return View(person);
		}
		#endregion

		#region Edit
		// GET: Person/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Person person = db.Persons.Find(id);
			if (person == null)
			{
				return HttpNotFound();
			}
			return View(person);
		}

		// POST: Person/Edit/5
		[HttpPost, ActionName("Edit")]
		[ValidateAntiForgeryToken]
		public ActionResult EditPost(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var personToUpdate = db.Persons.Find(id);
			if (TryUpdateModel(personToUpdate, "",
			   new string[] { "LastName", "FirstName" }))
			{
				try
				{
					db.SaveChanges();

					return RedirectToAction("Index");
				}
				catch (RetryLimitExceededException /* dex */)
				{
					//Log the error (uncomment dex variable name and add a line here to write a log.
					ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
				}
			}
			return View(personToUpdate);
		}
		#endregion

		#region Delete
		// GET: Person/Delete/5
		public ActionResult Delete(int? id, bool? saveChangesError = false)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			if (saveChangesError.GetValueOrDefault())
			{
				ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
			}
			Person person = db.Persons.Find(id);
			if (person == null)
			{
				return HttpNotFound();
			}
			return View(person);
		}

		// POST: Person/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id)
		{
			try
			{
				Person person = db.Persons.Find(id);
				db.Persons.Remove(person);
				db.SaveChanges();
			}
			catch (RetryLimitExceededException/* dex */)
			{
				//Log the error (uncomment dex variable name and add a line here to write a log.
				return RedirectToAction("Delete", new { id = id, saveChangesError = true });
			}
			return RedirectToAction("Index");
		} 
		#endregion
	}
}
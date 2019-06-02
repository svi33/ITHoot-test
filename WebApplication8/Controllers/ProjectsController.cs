using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication8.Data;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly CProjectContext _context;

        public ProjectsController(CProjectContext context)
        {
            _context = context;
        }

        // GET: Projects
        public IActionResult Index()
        {
            var projects = _context.Projects;
            if (projects.Count()<1)
            {
                return NotFound();
            }
            List<ProjectViewModel> PWM = new List<ProjectViewModel>();
            var MyCheckBoxList = new List<CBVeiwModel>();
            var MyViewModel = new ProjectViewModel();
            foreach (var project in projects)
            {
                var Results = from c in _context.Coders
                              select new
                              {
                                  c.CoderID,
                                  c.Name,
                                  Checked = ((from cp in _context.CoderProjects
                                              where (cp.ProjectID == project.ProjectID) & (cp.CoderID == c.CoderID)
                                              select cp).Count() > 0)
                              };
                MyViewModel = new ProjectViewModel();
                MyViewModel.ProjectID = project.ProjectID;
                MyViewModel.Title = project.Title;
                MyViewModel.Description = project.Description;
                MyCheckBoxList = new List<CBVeiwModel>();
                foreach (var cod in Results)
                {
                    MyCheckBoxList.Add(new CBVeiwModel { Id = cod.CoderID, Name = cod.Name, Checked = cod.Checked });
                }
                MyViewModel.Coders = MyCheckBoxList;
                PWM.Add(MyViewModel);

            }
            return View(PWM);

        }


        public ActionResult p_Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = _context.Projects
                .FirstOrDefault(m => m.ProjectID == id);
            if (project == null)
            {
                return NotFound();
            }

            var Results = from c in _context.Coders
                          select new
                          {
                              c.CoderID,
                              c.Name,
                              Checked = ((from cp in _context.CoderProjects
                                          where (cp.ProjectID == id) & (cp.CoderID == c.CoderID)
                                          select cp).Count() > 0)
                          };
            var MyViewModel = new ProjectViewModel();
            MyViewModel.ProjectID = id.Value;
            MyViewModel.Title = project.Title;
            MyViewModel.Description = project.Description;
            var MyCheckBoxList = new List<CBVeiwModel>();
            foreach (var cod in Results)
            {
                MyCheckBoxList.Add(new CBVeiwModel { Id = cod.CoderID, Name = cod.Name, Checked = cod.Checked });
            }
            MyViewModel.Coders = MyCheckBoxList;
            return PartialView(MyViewModel);
        }



       

        public ActionResult p_Create()
        {
            return PartialView();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectID,Title,Description")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

       


        // GET: Projects/Edit/5
        public ActionResult p_Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = _context.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }
            var Results = from c in _context.Coders
                          select new
                          {
                              c.CoderID,
                              c.Name,
                              Checked = ((from cp in _context.CoderProjects
                                          where (cp.ProjectID == id) & (cp.CoderID == c.CoderID)
                                          select cp).Count() > 0)
                          };
            var MyViewModel = new ProjectViewModel();
            MyViewModel.ProjectID = id.Value;
            MyViewModel.Title = project.Title;
            MyViewModel.Description = project.Description;
            var MyCheckBoxList = new List<CBVeiwModel>();
            foreach (var cod in Results)
            {
                MyCheckBoxList.Add(new CBVeiwModel { Id = cod.CoderID, Name = cod.Name, Checked = cod.Checked });
            }
            MyViewModel.Coders = MyCheckBoxList;
            return PartialView(MyViewModel);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProjectViewModel project)
        {

            if (ModelState.IsValid)
            {

                    var MyProject = _context.Projects.Find(project.ProjectID);
                    MyProject.Title = project.Title;
                    MyProject.Description = project.Description;
                    foreach(var item in _context.CoderProjects)
                    {
                        if (item.ProjectID==project.ProjectID)
                        {
                            _context.Entry(item).State = EntityState.Deleted;
                        }
                    }

                    foreach (var item in project.Coders)
                    {
                        if (item.Checked)
                        {
                            _context.CoderProjects.Add(new CoderProject { ProjectID=project.ProjectID, CoderID=item.Id});
                        }
                    }

                    await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

       

        public ActionResult p_Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = _context.Projects
                .FirstOrDefault(m => m.ProjectID == id);
            if (project == null)
            {
                return NotFound();
            }

            return PartialView(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Project proj)
        {
            var project = _context.Projects.Find(proj.ProjectID);
            _context.Projects.Remove(project);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.ProjectID == id);
        }
    }
}

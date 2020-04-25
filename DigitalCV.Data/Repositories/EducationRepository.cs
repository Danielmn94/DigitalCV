using DigitalCV.Data.Domain;
using DigitalCV.Data.Domain.Models;
using DigitalCV.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DigitalCV.Data.Repositories
{
    public class EducationRepository : IEducationRepository
    {
        private readonly DigitalCVContext _context;

        public EducationRepository(DigitalCVContext context)
        {
            _context = context;
        }

        public List<Education> GetEducations()
        {
            return _context.Educations.ToList();
        }

        public Education GetEducationFromID(int Id)
        {
            return _context.Educations.Where(e => e.Id == Id).FirstOrDefault();
        }

        public void CreateEducation(Education model)
        {
            _context.Add(model);

            _context.SaveChanges();
        }

        public void UpdateEducation(Education model)
        {
            var dbEducation = _context.Educations.Where(e => e.Id == model.Id).FirstOrDefault();

            dbEducation.NameOfEducation = model.NameOfEducation;
            dbEducation.School = model.School;
            dbEducation.TimePeriod = model.TimePeriod;
            dbEducation.Updated = DateTime.Now;

            _context.Update(dbEducation);

            _context.SaveChanges();
        }

        public void DeleteEducation(int Id)
        {
            var education = _context.Educations.Where(e => e.Id == Id).FirstOrDefault();

            _context.Educations.Remove(education);

            _context.SaveChanges();
        }
    }
}

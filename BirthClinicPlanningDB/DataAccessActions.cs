﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthClinicPlanningDB.Repositories;

namespace BirthClinicPlanningDB
{
    public class DataAccessActions: IDataAccessActions
    {
        private readonly Context _context;

        public IAppointmentRepository Appointments { get; private set; }

        //public repository object (by interface) decleration as property

        public DataAccessActions(Context context)
        {
            _context = context;
            Appointments = new AppointmentsRepository(_context);

            //Instantiate repository objects
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}

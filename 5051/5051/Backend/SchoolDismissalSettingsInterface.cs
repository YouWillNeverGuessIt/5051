﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _5051.Models;

namespace _5051.Backend
{

    /// <summary>
    /// Datasource Interface for Avatars
    /// </summary>
    public interface ISchoolDismissalSettingsInterface
    {
        SchoolDismissalSettingsModel Create(SchoolDismissalSettingsModel data);
        SchoolDismissalSettingsModel Read(string id);
        SchoolDismissalSettingsModel Update(SchoolDismissalSettingsModel data);
        bool Delete(string id);
        List<SchoolDismissalSettingsModel> Index();
        void Reset();
        void LoadDataSet(DataSourceDataSetEnum setEnum);
    }
}
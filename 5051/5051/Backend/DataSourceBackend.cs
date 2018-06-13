﻿using _5051.Models;
using System;

namespace _5051.Backend
{
    /// <summary>
    /// Class that manages the overall data sources
    /// </summary>
    public class DataSourceBackend
    {
        /// <summary>
        /// Hold one of each of the DataSources as an instance to the datasource
        /// </summary>
        public AvatarBackend AvatarBackend = AvatarBackend.Instance;
        public StudentBackend StudentBackend = StudentBackend.Instance;
        public ShopInventoryBackend ShopInventoryBackend = ShopInventoryBackend.Instance;
        public SchoolCalendarBackend SchoolCalendarBackend = SchoolCalendarBackend.Instance;
        public SchoolDismissalSettingsBackend SchoolDismissalSettingsBackend = SchoolDismissalSettingsBackend.Instance;

        /// <summary>
        /// Make into a Singleton
        /// </summary>
        private static volatile DataSourceBackend instance;
        private static object syncRoot = new Object();

        private DataSourceBackend()
        {
            // Avatar must be before Student, because Student needs the default avatarID
            AvatarBackend = AvatarBackend.Instance;
            StudentBackend = StudentBackend.Instance;
            ShopInventoryBackend = ShopInventoryBackend.Instance;
            SchoolCalendarBackend = SchoolCalendarBackend.Instance;
            SchoolDismissalSettingsBackend = SchoolDismissalSettingsBackend.Instance;
        }

        public static DataSourceBackend Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new DataSourceBackend();
                        }
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// Call for all data sources to reset
        /// </summary>
        public void Reset()
        {
            SchoolCalendarBackend.Reset();
            SchoolDismissalSettingsBackend.Reset();
            ShopInventoryBackend.Reset();

            AvatarBackend.Reset();
            StudentBackend.Reset();
        }

        /// <summary>
        /// Changes the data source, does not call for a reset, that allows for how swapping but keeping the original data in place
        /// </summary>
        public void SetDataSource(DataSourceEnum dataSourceEnum)
        {
            SchoolDismissalSettingsBackend.SetDataSource(dataSourceEnum);
            SchoolCalendarBackend.SetDataSource(dataSourceEnum);

            ShopInventoryBackend.SetDataSource(dataSourceEnum);

            // Avatar must be reset before Student, because Student needs the default avatarID
            AvatarBackend.SetDataSource(dataSourceEnum);
            StudentBackend.SetDataSource(dataSourceEnum);
        }

        /// <summary>
        /// Change between demo, default, and UT data sets
        /// </summary>
        /// <param name="SetEnum"></param>
        public void SetDataSourceDataSet(DataSourceDataSetEnum SetEnum)
        {
            SchoolDismissalSettingsBackend.SetDataSourceDataSet(SetEnum);
            SchoolCalendarBackend.SetDataSourceDataSet(SetEnum);
            ShopInventoryBackend.SetDataSourceDataSet(SetEnum);

            // Avatar must be reset before Student, because Student needs the default avatarID
            AvatarBackend.SetDataSourceDataSet(SetEnum);
            StudentBackend.SetDataSourceDataSet(SetEnum);
        }
    }
}
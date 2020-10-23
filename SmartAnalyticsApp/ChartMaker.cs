using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using System.Data.SqlClient;
using System.Data;
using DevExpress.XtraCharts;

namespace SmartAnalyticsApp
{
    static class ChartMaker
    {

        static string connectionString = @"Data Source=DESKTOP-VFFBM2L\MSSQLSERVER04;
                                        Initial Catalog=Dairy;Integrated Security=True";

        public static Control MakeChart(string proc, string dataMember, string argument, string range)
        {
            ChartControl chart = new ChartControl();
            chart.DataSource = DbConn.GetDataTable(proc);
            chart.SeriesDataMember = dataMember;
            chart.SeriesTemplate.ArgumentDataMember = argument;
            chart.SeriesTemplate.ValueDataMembers.AddRange(new string[] { range });
            chart.SeriesTemplate.View = new StackedBarSeriesView();
            chart.SeriesNameTemplate.BeginText = $"{dataMember}: ";
            chart.Dock = DockStyle.Fill;
            return chart;
        }
        
    }
}

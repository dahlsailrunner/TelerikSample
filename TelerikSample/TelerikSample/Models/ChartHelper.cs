using System;
using System.Collections.Generic;

namespace TelerikSample.Models
{
    public class PbChart
    {
        public int BillableCount { get; set; }
        public int VacantCount { get; set; }
        public decimal TotalCurrentCharges { get; set; }
        public string SupplierId { get; set; }
        public string PerEndDt { get; set; }
        // ReSharper disable InconsistentNaming
        public int Count_0_10 { get; set; }
        public int Count_10_20 { get; set; }
        public int Count_20_30 { get; set; }
        public int Count_30_40 { get; set; }
        public int Count_40_50 { get; set; }
        public int Count_50_60 { get; set; }
        public int Count_GT60 { get; set; }
        // ReSharper restore InconsistentNaming
    }
    public class CategoricalData
    {
        public object Category { get; set; }
        public double Value { get; set; }
    }
    public class LocalChart
    {
        public PbChart Chart { get; set; }
        public List<CategoricalData> CategoricalData
        {
            get
            {
                return new List<CategoricalData>()
                {
                    new CategoricalData() {Category = "< $10", Value = Chart.Count_0_10},
                    new CategoricalData() {Category = "$10's", Value = Chart.Count_10_20},
                    new CategoricalData() {Category = "$20's", Value = Chart.Count_20_30},
                    new CategoricalData() {Category = "$30's", Value = Chart.Count_30_40},
                    new CategoricalData() {Category = "$40's", Value = Chart.Count_40_50},
                    new CategoricalData() {Category = "$50's", Value = Chart.Count_50_60},
                    new CategoricalData() {Category = "> $60", Value = Chart.Count_GT60}
                };
            }
        }
        public List<CategoricalData> CategoricalData0
        {
            get
            {
                return new List<CategoricalData>()
                {
                    new CategoricalData() {Category = "< $10", Value = Chart.Count_0_10}
                };
            }
        }
        public List<CategoricalData> CategoricalData1
        {
            get
            {
                return new List<CategoricalData>()
                {
                    new CategoricalData() {Category = "$10's", Value = Chart.Count_10_20}
                };
            }
        }
        public List<CategoricalData> CategoricalData2
        {
            get
            {
                return new List<CategoricalData>()
                {
                    new CategoricalData() {Category = "$20's", Value = Chart.Count_20_30}
                };
            }
        }
        public List<CategoricalData> CategoricalData3
        {
            get
            {
                return new List<CategoricalData>()
                {
                    new CategoricalData() {Category = "$30's", Value = Chart.Count_30_40}
                };
            }
        }
        public List<CategoricalData> CategoricalData4
        {
            get
            {
                return new List<CategoricalData>()
                {
                    new CategoricalData() {Category = "$40's", Value = Chart.Count_40_50}
                };
            }
        }
        public List<CategoricalData> CategoricalData5
        {
            get
            {
                return new List<CategoricalData>()
                {
                    new CategoricalData() {Category = "$50's", Value = Chart.Count_50_60}
                };
            }
        }
        public List<CategoricalData> CategoricalData6
        {
            get
            {
                return new List<CategoricalData>()
                {
                    new CategoricalData() {Category = " > $60", Value = Chart.Count_GT60}
                };
            }
        }
        public LocalChart(PbChart chart)
        {
            if (chart == null) throw new ArgumentNullException("chart");
            Chart = chart;
        }
    }
}

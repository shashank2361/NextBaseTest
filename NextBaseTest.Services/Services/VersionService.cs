
using NextBaseTest.Core.Models;
using NextBaseTest.Data.Repository;
using NextBaseTest.Data.Models;
 
using System;
using System.Collections.Generic;
 
using System.Threading.Tasks;
using System.Linq;
using System.Globalization;

namespace NextBaseTest.Services
{
    public class VersionService : IVersionService
    {
        private readonly IVersionRepo versionsRepo;

        public VersionService(IVersionRepo _versionsRepo)
        {
            versionsRepo = _versionsRepo;
        }


   

        public async Task<IEnumerable<TestMonthlyVersionHistory>> GetMonthlyVersionHistory(string model)
        {
            var result = await versionsRepo.GetMonthlyVersionHistory(model);
            return result;

        }

        public async Task<Tuple<TestFirmware , TestFirmware>> GetbyVersionModelno(decimal version , string model)
        {

            var versionQueried = await versionsRepo.GetbyVersionModelno(version, model);
            var versionMax = await versionsRepo.GetLastVersionModelno(version, model);

            return new Tuple<TestFirmware, TestFirmware>(versionQueried, versionMax);
                
        }

        public async Task<IEnumerable<TestFirmware>> GetAllVersion()
        {
            return await versionsRepo.GetAllVersion();
        }

        public async Task<Chart> GetChartData()
        {
            var getallVersions = await versionsRepo.GetAllVersion();


            var datelabels = getallVersions.OrderBy(x =>x.ReleasedOn).Select(x =>   Convert.ToDateTime(x.ReleasedOn).ToString("yyyy") + "-" +  Convert.ToDateTime(x.ReleasedOn).ToString("MMM")).ToList();
            var dateLabelsDistinct = datelabels.Distinct().ToList();

            Chart _chart = new Chart();
            List<Datasets> _dataSet = new List<Datasets>();
            //Where(x => x.CameraModel == model)
            var complelistCameras = getallVersions.Select(x => x.CameraModel).Distinct().ToList();

            var backgroundColor = new string[] { "#BF3F3F", "#BF7F3F", "#7FBF3F", "#3FBFBF", "#7F3FBF", "#BFBF3F", "#3F7FBF", "#19334C", "#4C194C", "#19404C", "#FF0000", "#1EA3CC", "#C8A1AC", "#D1C5F5", "#8A6EE7", "#6EE774", "#E7B26E" ,"#19334C", "#4C194C", "#19404C", "#FF0000", "#1EA3CC", "#C8A1AC", "#D1C5F5", "#8A6EE7", "#6EE774", "#E7B26E"};

             int i = 0;
            foreach (var cameramodel in complelistCameras)
            {
                var response = await versionsRepo.GetMonthlyVersionHistory(cameramodel);


                var chartlist = response.Select(x => new ChartModel()
                {

                    CameraTotalMonth = x.CameraMonthTotal,
                    CountSerial = x.CountSerial,
                    CheckedOnMonth = x.CheckedOnMonth,
                    CheckedOnYear = x.CheckedOnYear,
                    CameraModel = x.CameraModel,
                    CameraVersion = x.CheckedVersion,


                });


              //  var labels = chartlist.Select(x => x.MonthYear).Distinct();
                //_chart.labels = labels.ToArray();
                _chart.labels = dateLabelsDistinct.ToArray();

                var distinctmodelVer = chartlist.Where(x => x.CameraModel == cameramodel).Select(x => x.CameraModel).Distinct().ToList();

               
                foreach (var item in distinctmodelVer)
                {
                    var data = new List<int>();
                        //chartlist.Where(x => x.CameraModelVer == item).Select(x => x.CountSerial).ToList();

                    foreach (var label in dateLabelsDistinct.ToList())
                    {
                        var camtotmon = chartlist.Where(x => x.MonthYear == label).Select(x => x.CameraTotalMonth).FirstOrDefault();
                        if (camtotmon > 0)
                        {
                                data.Add(camtotmon);
                        }
                        else
                        {
                            data.Add(0);
                        }
                      
                    }
                   
                    
                    _dataSet.Add(new Datasets()
                    {
                        
                        label = item,
                        data = data.ToArray(),
                        backgroundColor = backgroundColor[i],
                        borderColor = backgroundColor[i],
                        borderWidth = "4" ,
                         Fill = true

                    });
                    i++;
                }


                _chart.datasets = _dataSet;

            }

            return _chart;
        }
    }
}

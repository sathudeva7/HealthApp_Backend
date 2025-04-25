using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMSApi.Dtos.Report;
using IMSApi.Models;

namespace IMSApi.Mappers
{
    public static class ReportMapper
    {
        public static ReportDto ToReportDto(this Report report)
        {
            return new ReportDto
            {
                Id = report.Id,
                Content = report.Content,
                CreatedOn = report.CreatedOn,
                PatientId = report.PatientId,
                CreatedBy = report.CreatedBy,
                ImageId = report.ImageId
            };
        }

        public static Report ToReportFromCreate(this CreateReportDto reportDto, int imageId)
        {
            return new Report
            {
                Content = reportDto.Content,
                CreatedOn = reportDto.CreatedOn,
                CreatedBy = reportDto.CreatedBy,
                PatientId = reportDto.PatientId,
                ImageId = imageId
            };
        }
    }
}
﻿using Domain.Models;
using RecordConsumption.Dto.Practice;
using System.Collections.Generic;

namespace RecordConsumption.Services.PracticeService
{
    public interface IPracticeService
    {
        void CreateRange(List<PracticeEditDto> practicesDto);

        void EditRange(List<PracticeEditDto> practicesDto);

        List<PracticeDto> GetActualPracriceList(string towm = null);
    }
}

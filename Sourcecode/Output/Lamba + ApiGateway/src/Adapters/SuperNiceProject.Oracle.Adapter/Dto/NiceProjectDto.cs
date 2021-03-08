using SuperNiceProject.Oracle.Adapter.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using SuperNiceProject.Models;

namespace SuperNiceProject.Oracle.Adapter.Dto
{
    public class NiceProjectDto
    {
        public long NiceProjectId { get; set; }
        public string UniqueReference { get; set; }

        public static NiceProjectDto FromModel(NiceProjectModel model)
        {
            return new NiceProjectDto {
                NiceProjectId = model.NiceProjectId,
                UniqueReference = model.UniqueReference
            };
        }

        public NiceProjectModel ToModel()
        {
            return new NiceProjectModel {
                NiceProjectId = NiceProjectId,
                UniqueReference = UniqueReference
            };
        }
    }
}

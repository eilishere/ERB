﻿using ResumeBank.Entities;
using ResumeBank.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBank.Services
{
    public class AttachmentManagementService
    {
        private RBDbContext _rbDbContext;
        private AttachmentUnitOfWork _attachmentUnitOfWork;

        public AttachmentManagementService()
        {
            _rbDbContext = new RBDbContext();
            _attachmentUnitOfWork = new AttachmentUnitOfWork(_rbDbContext);
        }

        public IEnumerable<Attachment> GetAllGender()
        {
            return _attachmentUnitOfWork.AttachmentRepository.GetAll();
        }
        public bool AddAttachment(Attachment attachment)
        {
            try
            {
                var newAttachment = new Attachment();

                newAttachment.Id = attachment.Id;
                newAttachment.Caption = attachment.Caption;
                newAttachment.ImageUrl = attachment.ImageUrl;
                newAttachment.OriginalName = attachment.OriginalName;
                newAttachment.CurrentName = attachment.CurrentName;

                _attachmentUnitOfWork.AttachmentRepository.Add(newAttachment);
                _attachmentUnitOfWork.Save();

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}

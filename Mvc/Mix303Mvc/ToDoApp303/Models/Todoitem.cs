using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ToDoApp303.Models
{
    public class Todoitem:BaseEntity
    {
        [StringLength(200)]
        [Required(ErrorMessage = "Bu alanı doldurmak zorunludur.")]
        [DisplayName("Başlık")]
        public string Title { get; set; }

        [DisplayName("Açıklama")]
        public string Description { get; set; }

        [DisplayName("Durum")]
        public Status Status { get; set; }

        [DisplayName("Kategori Adı")]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [StringLength(200)]
        [DisplayName("Dosya Eki")]
        public string Attachment { get; set; }

        [DisplayName("Departman Adı")]
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        [DisplayName("Taraf Adı")]
        public int? SideId { get; set; }
        // [ForeignKey("SideId")]
        public virtual Side Side { get; set; }

        [DisplayName("Müşteri Adı")]
        public int? CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        [DisplayName("Yönetici Adı")]
        public int? ManagerId { get; set; }
        public virtual Contact Manager { get; set; }

        [DisplayName("Organizatör Adı")]
        public int? OrganizatorId { get; set; }
        public virtual Contact Organizator { get; set; }

        [DisplayName("Toplantı Tarihi")]
        [Required(ErrorMessage ="Tarih bilgisi zorunludur.")]
        [DataType("datetime-local")]
        public DateTime MeetingDate { get; set; }

        [DisplayName("Planlanan Tarih")]
        [Required(ErrorMessage = "Tarih bilgisi zorunludur.")]
        [DataType("datetime-local")]
        public DateTime PlannedDate { get; set; }

        [DisplayName("Bitiş Tarihi")]
        [Required(ErrorMessage = "Tarih bilgisi zorunludur.")]
        [DataType("datetime-local")]
        public DateTime FinishDate { get; set; }

        [DisplayName("Revize Tarihi")]
        [Required(ErrorMessage = "Tarih bilgisi zorunludur.")]
        [DataType("datetime-local")]
        public DateTime ReviseDate { get; set; }

        [DisplayName("Görüşme Konusu")]
        public string ConversationSubject { get; set; }

        [DisplayName("Destekleyen Firma")]
        public string SupporterCompany { get; set; }

        [DisplayName("Destekleyen Doktor")]
        public string SupporterDoctor { get; set; }

        [DisplayName("Görüşme Katılımcı Sayısı")]
        public int ConversationAttendeeCount { get; set; }

        [DisplayName("Planlanan Organizasyon Tarihi")]
        [Required(ErrorMessage = "Tarih bilgisi zorunludur.")]
        [DataType("datetime-local")]
        public DateTime ScheduledOrganizationDate { get; set; }

        [DisplayName("Mailleşme Konuları")]
        public string MaillingSubjects { get; set; }

        [DisplayName("Afiş Konusu")]
        public string PosterSubject { get; set; }

        [DisplayName("Afiş Sayısı")]
        public int PosterCount { get; set; }

        [DisplayName("Uzaktan Eğitim")]
        public string Elearning { get; set; }

        [DisplayName("Tarama Türleri")]
        public string TypeofScans { get; set; }

        [DisplayName("Taramalardaki Aso Sayısı")]
        public string AsoCountInScans { get; set; }

        [DisplayName("Organizasyon Türleri")]
        public string TypeOfOrganization { get; set; }

        [DisplayName("Organizasyondaki Aso Sayısı")]
        public string AsoCountInOrganizations { get; set; }

        [DisplayName("Aşı Organizasyonu Türleri")]
        public string TypeOfVaccinationOrganization { get; set; }

        [DisplayName("Aşı Organizasyondaki Aso Sayısı")]
        public string AsoCountInVaccinationOrganization { get; set; }

        [DisplayName("Afiş İçin Tazminat Miktarı")]
        public string AmountOfCompansationForPoster { get; set; }

        [DisplayName("Kurumsal Verimlilik Raporu")]
        public string CorporateProductivityReport { get; set; }


    }
}
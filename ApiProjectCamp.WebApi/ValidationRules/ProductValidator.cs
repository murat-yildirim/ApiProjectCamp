using ApiProjectCamp.WebApi.Entities;
using FluentValidation;

namespace ApiProjectCamp.WebApi.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product> //AbstracValidatordan Product sınıfı için miras alıyoruz
    {
        public ProductValidator() //ProductValidator sınıfının constructor'ı
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün Adını Boş Geçmeyin");
            RuleFor(x=>x.Name).MinimumLength(2).WithMessage("Ürün Adı En Az 2 Karakter Olmalıdır");
            RuleFor(x=>x.Name).MaximumLength(50).WithMessage("Ürün Adı En Fazla 50 Karakter Olmalıdır");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün Fiyatını Boş Geçmeyin").GreaterThan(0).WithMessage("Ürün Fiyatı Negatif Olamaz").LessThan(1000).WithMessage("Ürün fiyatı bu kadar yüksek olamaz girdğiniz değeri kontrol edin");


            RuleFor(x=>x.Description).NotEmpty().WithMessage("Ürün Açıklamasını Boş Geçmeyin");
        }
       
    }
}

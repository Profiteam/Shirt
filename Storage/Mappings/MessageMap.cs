using Domain.Enum;
using Domain.Messages;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storage.Mappings
{
    public class MessageMap : ClassMap<Message>
    {
        public MessageMap()
        {
            Table("messages");

            Id(u => u.ID, "id");

            Map(u => u.Email, "email");
            Map(u => u.FirstAddress, "first_address");
            Map(u => u.SecondAddress, "second_address");
            Map(u => u.ColorType, "color_type").CustomType<ColorType>();
            Map(u => u.CountType, "count_type").CustomType<CountType>();
            Map(u => u.SizeEnum, "size_enum").CustomType<SizeEnum>();
            Map(u => u.PhoneNumber, "phone_number");
            Map(u => u.Date, "date");

            Map(u => u.Deleted, "deleted").Not.Nullable();

        }
    }
}

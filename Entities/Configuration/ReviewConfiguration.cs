using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasIndex(p => new { p.Id }).IsUnique(true);
            builder.HasData
            (
            new Review
            {
                Id = new Guid("41332237-ffc1-4c63-8edf-1fd1ec602473"),
                CreatedAt = DateTime.Now,
                content="A content",
                title = "A title", 
                star=1,
                status = ReviewStatus.Approved,
                userId= new Guid("f27f1c31-9b90-4406-8e7a-6dd1e6a7535c")

            },
            new Review
            {
                Id = new Guid("35d174b7-57b9-44bd-842a-4ee070b786bb"),
                CreatedAt = DateTime.Now,
                content = "Another content",
                title = "Another Title",
                star = 5,
                status = ReviewStatus.Pending,
                userId = new Guid("f27f1c31-9b90-4406-8e7a-6dd1e6a7535c")
            }
            );

        }
    }
}

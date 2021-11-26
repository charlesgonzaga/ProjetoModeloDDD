using ProjetoModeloDDD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ProjetoModeloDDD.Infra.Configurations
{
    public class PessoaConfiguration : IEntityTypeConfiguration<PessoaEntity>
    {
        public void Configure(EntityTypeBuilder<PessoaEntity> builder)
        {
            builder.ToTable("Pessoas");
            builder.HasKey(p => p.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Property(x => x.DataNascimento)
                .HasColumnName("DataNascimento")
                .HasColumnType("datetime")
                .IsRequired();

            builder
                .Property(x => x.DataCadastro)
                .HasColumnName("DataCadastro")
                .HasColumnType("datetime")
                .IsRequired();

            builder
                .Property(x => x.DataAlteracao)
                .HasColumnName("DataAlteracao")
                .HasColumnType("datetime");
        }
    }
}

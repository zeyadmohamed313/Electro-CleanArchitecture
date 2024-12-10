﻿using Electro.Data.AppDbContext;
using Electro.Data.Entites.Identity;
using Electro.Infrastructure.Abstracts;
using Electro.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Electro.Data.Helper;
using Microsoft.Extensions.Configuration;

namespace Electro.Infrastructure
{
    public static class ServicesRegisterations
    {
        public static IServiceCollection ServicesRegisteration(this IServiceCollection services , IConfiguration configuration)
        {

            #region ServicesRegisteration

            // Add services to the container.
            services.AddDbContext<Context>(options =>
            options.UseSqlServer("Data Source=DESKTOP-8QKV55J\\SQLEXPRESS;Initial Catalog=Electro;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));

            services.AddIdentity<User, IdentityRole<int>>(option =>
            {
                // Configure Identity options if needed
                option.Password.RequireDigit = true;
                option.Password.RequiredLength = 8;

                // Password settings.
                option.Password.RequireDigit = true;
                option.Password.RequireLowercase = true;
                option.Password.RequireNonAlphanumeric = true;
                option.Password.RequireUppercase = true;
                option.Password.RequiredLength = 6;
                option.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                option.Lockout.MaxFailedAccessAttempts = 5;
                option.Lockout.AllowedForNewUsers = true;

                // User settings.
                option.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                option.User.RequireUniqueEmail = true;
                // Add other options...
            })
            .AddEntityFrameworkStores<Context>()
            .AddDefaultTokenProviders();

            var jwtSettings = new Data.Helper.JwtSettings();
            configuration.GetSection(nameof(jwtSettings)).Bind(jwtSettings);
            var emailSettings = new EmailSettings();
            configuration.GetSection(nameof(emailSettings)).Bind(emailSettings);

            services.AddSingleton(jwtSettings);
            services.AddSingleton(emailSettings); // 

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = jwtSettings.ValidateIssuer,
                    ValidIssuers = new[] { jwtSettings.Issuer },
                    ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                    ValidAudience = jwtSettings.Audience,
                    ValidateAudience = jwtSettings.ValidateAudience,
                    ValidateLifetime = jwtSettings.ValidateLifeTime,
                };
            });


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Electro", Version = "v1" });
                c.EnableAnnotations();

                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
            {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            },
            Array.Empty<string>()
            }
           });
            });
            #endregion

            return services;
        }
    }
}

﻿using Microsoft.Extensions.Logging;
using Subflow.NET.Engine.Validation.Enums;
using Subflow.NET.Engine.Validation.Interfaces;
using System;
using System.IO;

namespace Subflow.NET.Engine.Validation.Rules
{
    // Pravidlo: kontrola existence souboru
    public class FileExistsRule : BaseValidationRule<string>
    {
        private readonly ILogger<FileExistsRule> _logger;

        public override ValidationSeverity DefaultSeverity => ValidationSeverity.Error;

        public FileExistsRule(ILogger<FileExistsRule> logger)
        {
            _logger = logger;
        }

        public override void Validate(string input)
        {
            if (!File.Exists(input))
            {
                _logger.LogError("Soubor '{Path}' nebyl nalezen.", input);
                throw new FileNotFoundException($"Soubor '{input}' nebyl nalezen.");
            }
        }
    }
}
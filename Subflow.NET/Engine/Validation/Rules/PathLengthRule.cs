﻿using Microsoft.Extensions.Logging;
using Subflow.NET.Engine.Validation.Enums;
using Subflow.NET.Engine.Validation.Interfaces;
using System;
using System.IO;

namespace Subflow.NET.Engine.Validation.Rules
{
    // Pravidlo: kontrola délky cesty
    public class PathLengthRule : BaseValidationRule<string>
    {
        private readonly ILogger<PathLengthRule> _logger;
        private readonly int _maxLength;

        public override ValidationSeverity DefaultSeverity => ValidationSeverity.Warning;

        public PathLengthRule(ILogger<PathLengthRule> logger, int maxLength = 260)
        {
            _logger = logger;
            _maxLength = maxLength;
        }

        public override void Validate(string input)
        {
            if (input.Length > _maxLength)
            {
                _logger.LogWarning("Cesta k souboru je příliš dlouhá. Délka: {Length}, Max: {Max}", input.Length, _maxLength);
                throw new PathTooLongException($"Cesta k souboru nesmí přesáhnout {_maxLength} znaků.");
            }
        }
    }
}
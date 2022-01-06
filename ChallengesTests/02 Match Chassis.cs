using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace C02_MatchChassisNamespace
{
    public class MatchChassisSolver
    {
        public static Dictionary<string, int> ToHistogram(string[] instruments)
        {
            var histogram = new Dictionary<string, int>();
            foreach (string instrument in instruments)
            {
                if (!histogram.ContainsKey(instrument))
                {
                    histogram.Add(instrument, 0);
                }
                histogram[instrument]++;
            }

            return histogram;
        }

        public static bool MatchChassis(string[] configurationChassis, string[] physicalChassis)
        {
            var configurationHistogram = ToHistogram(configurationChassis);
            var physicalHistogram = ToHistogram(physicalChassis);

            foreach (string instrument in configurationHistogram.Keys)
            {
                if (!physicalHistogram.ContainsKey(instrument))
                {
                    return false;
                }

                int numInConfiguration = configurationHistogram[instrument];
                int numInPhysical = physicalHistogram[instrument];

                if (numInConfiguration > numInPhysical)
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class MatchChassisTests
    {
        [Fact]
        public void MatchChassis_WhenChassisEqual_ShouldMatch()
        {
            var configurationChassis = new[]
            {
                "NI PXIe-6570",
                "NI PXIe-6368",
                "NI PXIe-4143",
                "NI PXIe-4463",
                "NI PXIe-4464",
                "NI PXIe-5433 (2CH)",
                "NI PXIe-5162 (4CH)",
                "NI PXIe-7822R",
                "NI PXI-2567",
                "NI PXIe-4139",
                "NI PXIe-4081",
                "NI PXI-4110",
                "NI USB-6509",
            };

            var physicalChassis = new[]
            {
                "NI PXIe-5433 (2CH)",
                "NI PXIe-5162 (4CH)",
                "NI PXIe-6570",
                "NI PXIe-6368",
                "NI PXIe-4143",
                "NI PXIe-7822R",
                "NI PXIe-4463",
                "NI PXIe-4464",
                "NI PXIe-4081",
                "NI PXI-2567",
                "NI PXIe-4139",
                "NI PXI-4110",
                "NI USB-6509",
            };

            bool matched = MatchChassisSolver.MatchChassis(configurationChassis, physicalChassis);
            matched.Should().BeTrue();
        }

        [Fact]
        public void MatchChassis_WhenPhysicalInstrumentMissing_ShouldNotMatch()
        {
            var configurationChassis = new[]
            {
                "NI PXIe-6570",
                "NI PXIe-6368",
                "NI PXIe-4143",
                "NI PXIe-4463",
                "NI PXIe-4464",
                "NI PXIe-5433 (2CH)",
                "NI PXIe-5162 (4CH)",
                "NI PXIe-7822R",
                "NI PXI-2567",
                "NI PXIe-4139",
                "NI PXIe-4081",
                "NI PXI-4110",
                "NI USB-6509",
            };

            var physicalChassis = new[]
            {
                "NI PXIe-6570",
                "NI PXIe-6368",
                "NI PXIe-4143",
                "NI PXIe-4463",
                "NI PXIe-4464",
                "NI PXIe-5433 (2CH)",
                "NI PXIe-5162 (4CH)",
                "NI PXIe-7822R",
                "NI PXI-2567",
                "NI PXIe-4139",
                "NI PXIe-4081",
                "NI PXI-4110",
            };

            bool matched = MatchChassisSolver.MatchChassis(configurationChassis, physicalChassis);
            matched.Should().BeFalse();
        }

        [Fact]
        public void MatchChassis_WhenAdditionalPhysicalInstruments_ShouldMatch()
        {
            var configurationChassis = new[]
            {
                "NI PXIe-6570",
                "NI PXIe-6368",
                "NI PXIe-4143",
                "NI PXIe-4463",
                "NI PXIe-4464",
                "NI PXIe-5433 (2CH)",
                "NI PXIe-5162 (4CH)",
                "NI PXIe-7822R",
                "NI PXI-2567",
                "NI PXIe-4139",
                "NI PXIe-4081",
                "NI PXI-4110",
            };

            var physicalChassis = new[]
            {
                "NI PXIe-6570",
                "NI PXIe-6368",
                "NI PXIe-4143",
                "NI PXIe-4463",
                "NI PXIe-4464",
                "NI PXIe-5433 (2CH)",
                "NI PXIe-5162 (4CH)",
                "NI PXIe-7822R",
                "NI PXI-2567",
                "NI PXIe-4139",
                "NI PXIe-4081",
                "NI PXI-4110",
                "NI USB-6509",
            };

            bool matched = MatchChassisSolver.MatchChassis(configurationChassis, physicalChassis);
            matched.Should().BeTrue();
        }

        [Fact]
        public void MatchChassis_WhenAdditionalPhysicalInstrumentsOfSameModel_ShouldMatch()
        {
            var configurationChassis = new[]
            {
                "NI PXIe-6570",
            };

            var physicalChassis = new[]
            {
                "NI PXIe-6570",
                "NI PXIe-6570",
            };

            bool matched = MatchChassisSolver.MatchChassis(configurationChassis, physicalChassis);
            matched.Should().BeTrue();
        }

        [Fact]
        public void MatchChassis_WhenAdditionalConfigurationInstrumentsOfSameModel_ShouldNotMatch()
        {
            var configurationChassis = new[]
            {
                "NI PXIe-6570",
                "NI PXIe-6570",
            };

            var physicalChassis = new[]
            {
                "NI PXIe-6570",
            };

            bool matched = MatchChassisSolver.MatchChassis(configurationChassis, physicalChassis);
            matched.Should().BeFalse();
        }

        [Fact]
        public void MatchChassis_StressTest()
        {
            var N = 1000000;
            var configurationChassis = new string[N];
            var physicalChassis = new string[N];

            for (int i = 0; i < N; i++)
            {
                configurationChassis[i] = i.ToString();
                physicalChassis[i] = i.ToString();
            }

            bool matched = MatchChassisSolver.MatchChassis(configurationChassis, physicalChassis);
            matched.Should().BeTrue();
        }
    }
}
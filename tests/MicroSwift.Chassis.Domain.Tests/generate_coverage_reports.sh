#!/bin/bash

# Script Name: generate_coverage_reports.sh
# Description: This script generates coverage reports using ReportGenerator.
#              It searches for the coverage.cobertura.xml file and generates
#              the reports in the CoverageReports folder relative to its location.

# Find the coverage XML file
coverage_files=$(find . -name "coverage.cobertura.xml")

# If the coverage XML file is not found, display an error message and exit
if [ -z "$coverage_files" ]; then
    echo "Error: No coverage XML files found."
    exit 1
fi

# Loop through each coverage report file
for coverage_file in $coverage_files; do
  # Extract the directory containing the coverage report file
  output_dir="$(dirname "$coverage_file")/CoverageReports"

  # Generate the report using reportgenerator
  reportgenerator "-reports:$coverage_file" "-targetdir:$output_dir" -reporttypes:Html
done

echo "Coverage reports generated successfully."

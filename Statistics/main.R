Sys.setenv(RSTUDIO_PANDOC="E:/Aplicaciones/RStudio/resources/app/bin/quarto/bin/tools");
rmarkdown::render(
  input = "E:\\Doctorado\\PrivacyAssessmentFrontend\\Statistics\\Statistics.Rmd", 
  output_format = "html_document",
  output_file = "Statistics.html",
  output_dir = "E:\\Doctorado\\PrivacyAssessmentFrontend\\Statistics")

# A GPT-Based Assessment of Alignment Between Privacy Legal Frameworks & ISO/IEC 27701:2025: A Latin American Case Study

This repository provides all the files and elements required for experiments reproducibility of the frontend component of the research project: "A GPT-Based Assessment of Alignment Between Privacy Legal Frameworks & ISO/IEC 27701:2025: A Latin American Case Study".

This research is part of the project "PRIVIA: Identificación Automatizada de Brechas de Privacidad en Ecuador usando Inteligencia Artificial Generativa y LLMs" conducted by Escuela Politécnica Nacional.

## Research information

- **Main project:** "PRIVIA: Identificación Automatizada de Brechas de Privacidad en Ecuador usando Inteligencia Artificial Generativa y LLMs" conducted by Escuela Politécnica Nacional.
- **Main project reference:** PIGR-24-06.
- **Date:** 2026-02-01.

## How to use this repository?

In order to use the frontend component, first the backend component, available in https://github.com/dcevallossalas/PrivacyAssessmentBackend, must be deployed.

Next, modify the App.config file to determine the general parameters of execution of the frontend application.

- protocol: Determine if the protocol to be used with the backend component will be **http** or **https**.
- endpoint: Set the name domain or the IP address (and port number if it is different to 80) where the backend component is running (e.g., 192.168.1.75 or 192.168.1.75:8080).
- apiKey: Set the OpenAI's api key in order to use different GPT models.
- path: Set the path to the statistics folder where the results of analysis will be stored (e.g., E:\PrivacyAssessmentFrontend\Statistics). The file Statistics.Rmd must be within this folder.
- rscript: Set the name of the R core script to execute remotely the R notebook (e.g., main.R).
- rpath: Set the path to the folder where the rscript is located (e.g., E:\Aplicaciones\R\bin).

Once the App.config file has been configured, open the .sln solution and execute the application.

The file Normatives.rar contains a video with an example of the execution of the application.
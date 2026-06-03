# Flujo de trabajo del proyecto

## Estrategia seleccionada

Se utilizó un flujo de trabajo basado en ramas, similar a Git Flow simplificado.

## Ramas principales

- main: rama estable del proyecto.
- develop: rama de integración.
- feature/*: ramas utilizadas para desarrollar funcionalidades específicas.

## Ramas creadas

- feature/entidades
- feature/controlador
- feature/formularios
- feature/dashboard
- feature/documentacion
- feature/github-actions

## Proceso aplicado

1. Se creó una rama para cada funcionalidad.
2. Se desarrollaron los cambios en la rama correspondiente.
3. Se realizaron commits descriptivos.
4. Se subieron las ramas a GitHub.
5. Se creó un Pull Request hacia develop.
6. Un integrante revisó el cambio.
7. Se aprobó el Pull Request.
8. Se fusionó la rama hacia develop.
9. Finalmente, develop se integró hacia main.

## Justificación

Este flujo permite evitar la pérdida de versiones, mejorar la organización del equipo, revisar los cambios antes de integrarlos y reducir errores en el proyecto.

## Relación con la problemática

El uso de ramas, commits y Pull Requests permite solucionar la pérdida de versiones del código y mejorar la colaboración del equipo. GitHub Actions permite automatizar la validación del proyecto antes de integrar cambios importantes.

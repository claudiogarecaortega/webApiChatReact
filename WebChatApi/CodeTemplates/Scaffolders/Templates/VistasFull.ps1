[T4Scaffolding.Scaffolder(Description = "Enter a description of ABMController here")][CmdletBinding()]
param(   
	[parameter(Mandatory = $false)][string]$Model,
    [string]$Project,
	[string]$CodeLanguage = "cs",
	[switch]$Force = $false,
	[string]$ForceMode,
	[parameter(Mandatory = $false)][string]$CarpetaDominio,
	[parameter(Mandatory = $false)][string]$Tabla,
	[parameter(Mandatory = $false)][string]$Key,
	[switch]$NoChildItems = $false,
	[string[]]$TemplateFolders
)
$items = Get-ChildItem -Path "D:\SistemaIntegradoFerias\Dominio\SistemaStock"
foreach ($item in $items)
{

      # if the item is a directory, then process it.
      if ($item.Attributes -eq "Directory")
      {
           # Write-Host  "$("C:\Users\garecaor\Documents\Beta\trunk\Dominio\")$($item.Name) "
			if($item.Name -ne "bin" -and $item.Name -ne "obj" -and $item.Name -ne "Properties" -and $item.Name -and "AttachmentDominio" -and $item.Name -ne "IdentificableObject" -and $item.Name -ne "Properties" )
			{
           
			$files = Get-ChildItem -Path  "$("D:\SistemaIntegradoFerias\Dominio\SistemaStock\")$($item.Name) "
			
				foreach ($file in $files)
				{
					Write-Host $file.Name
				# if the item is NOT a directory, then process it.
						if ($file.Attributes -ne "Directory" )
						{
						 $CarpetaDominio="$($CarpetaDominio)$($item.Name)"
						 	$s="$($s)$($file.Name)"
							$Model=$s.Substring(0, $s.IndexOf('.'))

									# Interpret the "Force" and "ForceMode" options
									$overwriteController = $Force -and ((!$ForceMode) -or ($ForceMode -eq "ControllerOnly"))
									$overwriteFilesExceptController = $Force -and ((!$ForceMode) -or ($ForceMode -eq "PreserveController"))

									# Creo el Modelo
									$namespaceModelo = "Dominio." + $CarpetaDominio
									$proyectoDomino = "Dominio"

									$outputPath = Join-Path $CarpetaDominio $Model

									$templateName = "ModelTemplate"
									Add-ProjectItemViaTemplate $outputPath -Template $templateName -Model @{
										Name = $Model;
										Namespace = $namespaceModelo; 
									} -SuccessMessage "Added Model {0}" -TemplateFolders $TemplateFolders -CodeLanguage $CodeLanguage -Project $proyectoDomino -Force:$overwriteController



									# Creo el ViewModel
									$proyectoInterfaz = "Modelos"
									$namespaceViewModel = "Modelos.ViewModels"
									$viewModel = $Model + "ViewModel"

									$outputPath = "ViewModels" 
									$outputPath = Join-Path $outputPath $viewModel


									$templateName = "ViewModelTemplate"
									Add-ProjectItemViaTemplate $outputPath -Template $templateName -Model @{
										Name = $viewModel;
										Namespace = $namespaceViewModel; 
									} -SuccessMessage "Added ViewModel {0}" -TemplateFolders $TemplateFolders -CodeLanguage $CodeLanguage -Project $proyectoInterfaz -Force:$overwriteController



									# Creo la interfaz del ViewModelMapper
									$viewModelMapperInterface = "I" + $ViewModel + "Mapper"
									$namespaceViewmodelMapperInterface = "Modelos.ViewModelMappers.Interfaces"
									$outputPath = Join-Path "ViewModelMappers/Interfaces" $viewModelMapperInterface

									$templateName = "ViewModelMapperInterfaceTemplate"
									Add-ProjectItemViaTemplate $outputPath -Template $templateName -Model @{
										Name = $viewModelMapperInterface;
										ModelName = $Model;
										ViewModelName = $ViewModel;
										ModelNamespace = $namespaceModelo;
										ViewModelNamespace = $namespaceViewModel;
										Namespace = $namespaceViewmodelMapperInterface;
									} -SuccessMessage "Added ViewModelInterface {0}" -TemplateFolders $TemplateFolders -CodeLanguage $CodeLanguage -Project $proyectoInterfaz -Force:$overwriteController



									# Creo el ViewModelMapper
									$viewModelMapper = $ViewModel + "Mapper"
									$namespaceViewModelMapper = "Modelos.ViewModelMappers"
									$outputPath =  "ViewModelMappers"
									$outputPath = Join-Path $outputPath $viewModelMapper

									$templateName = "ViewModelMapperTemplate"
									Add-ProjectItemViaTemplate $outputPath -Template $templateName -Model @{
										Name = $viewModelMapper;
										ModelName = $Model;
										ViewModelName = $ViewModel;
										Namespace = $namespaceViewModelMapper;
										ModelNamespace = $namespaceModelo;
										ViewModelNamespace = $namespaceViewModel;
										InterfaceNamespace = $namespaceViewmodelMapperInterface;
									} -SuccessMessage "Added ViewModelMapper {0}" -TemplateFolders $TemplateFolders -CodeLanguage $CodeLanguage -Project $proyectoInterfaz -Force:$overwriteController



									# Creo el Controller
									$ControllerName = $Model + "Controller"
									$namespaceController = "AplicacionPublica.Controllers"

									$outputPath = Join-Path Controllers $ControllerName

									$templateName = "ABMControllerTemplate"
									##Add-ProjectItemViaTemplate $outputPath -Template $templateName -Model @{
									##	ControllerName = $ControllerName;
									##	ModelName = $Model;
									##	ViewModelName = $ViewModel; 
									##	ControllerNamespace = $namespaceController;
									##	ModelNamespace = $namespaceModelo;
									##	ViewModelNamespace = $namespaceViewModel;
									##} -SuccessMessage "Added controller {0}" -TemplateFolders $TemplateFolders -CodeLanguage $CodeLanguage -Project $Project -Force:$overwriteController


									# Creo Interfaz del DAO
									$persistenciaProject = "Persistencia"
									$namespaceDAOInterfaz = "Persistencia.Daos.Interfaces"
									$IDAOName = "I" + $Model + "Dao"
									$outputPath = Join-Path "Daos/Interfaces" $IDAOName

									$templateName = "IDAOTemplate"
									Add-ProjectItemViaTemplate $outputPath -Template $templateName -Model @{
										Name = $IDAOName;
										ModelName = $Model;
										Namespace = $namespaceDAOInterfaz;
										ModelNamespace = $namespaceModelo;
									} -SuccessMessage "Added Interfaz DAO {0}" -TemplateFolders $TemplateFolders -CodeLanguage $CodeLanguage -Project $persistenciaProject -Force:$overwriteController



									# Creo el DAO
									$namespaceDAO = "Persistencia.Daos"
									$DAOName = $Model + "Dao"
									$outputPath = Join-Path "Daos" $DAOName

									$templateName = "DAOTemplate"
									Add-ProjectItemViaTemplate $outputPath -Template $templateName -Model @{
										Name = $DAOName;
										ModelName = $Model;
										Namespace = $namespaceDAO;
										ModelNamespace = $namespaceModelo;
									} -SuccessMessage "Added DAO {0}" -TemplateFolders $TemplateFolders -CodeLanguage $CodeLanguage -Project $persistenciaProject -Force:$overwriteController


									# Creo el Mapper
									$namespaceMapper = "Persistencia.Mappers"
									$mapperName = $Model + "Map"

									$outputPath = Join-Path "Mappers" $mapperName

									$templateName = "MapperTemplate"
									Add-ProjectItemViaTemplate $outputPath -Template $templateName -Model @{
										Name = $mapperName;
										Namespace = $namespaceMapper;
										ModelName = $Model;
										ModelNamespace = $namespaceModelo;
										Tabla = $Tabla;
										Key = $Key;
									} -SuccessMessage "Added Mapper {0}" -TemplateFolders $TemplateFolders -CodeLanguage $CodeLanguage -Project $persistenciaProject -Force:$overwriteController


									# Creo las vistas
									#if (!$NoChildItems) {
									#	$controllerNameWithoutSuffix = [System.Text.RegularExpressions.Regex]::Replace($ControllerName, "Controller$", "", [System.Text.RegularExpressions.RegexOptions]::IgnoreCase)

									#	Scaffold View -Template Create -ViewName Create -ModelType $viewModel -Controller $controllerNameWithoutSuffix
									#	Scaffold View -Template Delete -ViewName Delete -ModelType $viewModel -Controller $controllerNameWithoutSuffix
									#	Scaffold View -Template Details -ViewName Details -ModelType $viewModel -Controller $controllerNameWithoutSuffix
									#	Scaffold View -Template Edit -ViewName Edit -ModelType $viewModel -Controller $controllerNameWithoutSuffix
									#	Scaffold View -Template Index -ViewName Index -ModelType $viewModel -Controller $controllerNameWithoutSuffix
									#}
									$CarpetaDominio=""
									$s=""
									$Model=""
								}
								 
							
						}
				
			}
      }
}

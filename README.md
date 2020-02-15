# Photo Folder Rename

A simple utility to rename folders from one date format to another.

## Usage

```cli
Usage:
  photo-folder-rename <directory> <searchPattern> <originalDateFormat> <newDateFormat>

Arguments:
  <directory>           Directory to search.
                            Default: ".\"
  <searchPattern>       Search pattern to filter folders. This pattern accepts wildcards and literals but not regex.
                            Default: "*-*-*"
  <originalDateForm>    The exact date format of the existing folders (ex: "M-d-yyyy", "MMM-dd-yyyy").
                            Default: "M-d-yyyy"
  <newDateForm>         The new date format of the folders will be renamed to (ex: "yyyy-MM-dd", "yyyy-MM-dd-hh-mm").
                            Default: "yyyy-MM-dd"
```

## Publish & Build

To publish to a single executable run the following command in the root project directory.

```cli
dotnet publish -r win-x64 -c release /p:PublishSingleFile=true
```


### Usage

```cli
Usage:
  photo-folder-rename <directory> <searchPattern> <originalDateFormat> <newDateFormat>

Arguments:
  <directory>           Directory to search.
                            Default: ".\"
  <searchPattern>       Search pattern to filter folders. This pattern accepts wildcards and literals but not regex.
                            Default: "*-*-*"
  <originalDateForm>    The exact date format of the existing folders (ex: "MM-dd-yyyy", "ddd, MMM dd, yyyy").
                            Default: "MM-dd-yyyy"
  <newDateForm>         The new date format of the folders will be renamed to (ex: "yyyy-MM-dd", "yyyy-MM-dd-hh-mm").
                            Default: "yyyy-MM-dd"
```

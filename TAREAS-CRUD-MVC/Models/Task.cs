using System;
using System.Collections.Generic;

namespace TAREAS_CRUD_MVC.Models;

public partial class Task
{
    public int IdTask { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
}

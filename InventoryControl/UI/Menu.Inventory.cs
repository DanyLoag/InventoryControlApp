using System;
using AlmacenDataContext;
using AlmacenSQLiteEntities;

public static partial class UI
{
    static void ManageInventory()
    {
        do
        {
            WriteLine("Administrar inventario Menu:");
            WriteLine("1: Agregar nuevo material"); //check
            WriteLine("2: Modificar material");
            WriteLine("3: Eliminar material"); //check
            WriteLine("4: Salir");
            String option = ReadLine()??"";
            Clear();

            switch (option)
            {
                case "1":
                    CrudFuntions.NewMaterial();
                    break;
                case "2":
                    
                    break;
                case "3":
                    //CrudFuntions.ListMaterialsWithHighlight();
                    int materialId = CrudFuntions.SearchId();
                    IAlmacenDataContext? db = (IAlmacenDataContext)new Almacen();
                    int deletedMaterials = CrudFuntions.DeleteMaterials(materialId,db);
                    WriteLine($"{deletedMaterials} materiales eliminados.");
                    WriteLine();
                    //CrudFuntions.ListMaterialsWithHighlight();
                    break;
                case "4":
                    return;
                default:
                    break;
            }
        } while (true);
    }
}
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {
    [HttpGet("/categories/{categoryId}/items/new")]
    public ActionResult CreateForm(int categoryId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category category = Category.Find(categoryId);
      return View(category);
    }

    [HttpGet("/items/{id}/update")]
    public ActionResult UpdateForm(int id)
    {
      Item thisItem = Item.Find(id);
      return View(thisItem);
    }

    [HttpPost("/items/{id}/update")]
    public ActionResult Update(int id, string newDescription)
    {
        Item thisItem = Item.Find(id);
        thisItem.Edit(newDescription);
        return RedirectToAction("Index");
    }

    [HttpPost("/items/{id}/delete")]
    public ActionResult Delete(int id)
    {
        Item thisItem = Item.Find(id);
        thisItem.Delete();
        return RedirectToAction("Index");
    }
    // [HttpGet("/categories/{categoryId}/items/{itemId}")]
    // public ActionResult Details(int categoryId, int itemId)
    // {
    //   Item item = Item.Find(itemId);
    //   Dictionary<string, object> model = new Dictionary<string, object>();
    //   Category category = Category.Find(categoryId);
    //   model.Add("item", item);
    //   model.Add("category", category);
    //   return View(item);
    // }
  }
}

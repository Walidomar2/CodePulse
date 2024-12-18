import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoriesListComponent } from './feature/category/categories-list/categories-list.component';
import { AddCategoryComponent } from './feature/category/add-category/add-category.component';

const routes: Routes = [
  {
    path: 'admin/categories',
    component: CategoriesListComponent
  },
  {
    path: 'admin/categories/add',
    component: AddCategoryComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

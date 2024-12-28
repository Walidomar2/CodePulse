import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoriesListComponent } from './feature/category/categories-list/categories-list.component';
import { AddCategoryComponent } from './feature/category/add-category/add-category.component';
import { EditCategoryComponent } from './feature/category/edit-category/edit-category.component';
import { DeleteCategoryComponent } from './feature/category/delete-category/delete-category.component';
import { BlogpostListComponent } from './feature/blog-post/blogpost-list/blogpost-list.component';
import { AddBlogpostComponent } from './feature/blog-post/add-blogpost/add-blogpost.component';

const routes: Routes = [
  {
    path: 'admin/categories',
    component: CategoriesListComponent
  },
  {
    path: 'admin/categories/add',
    component: AddCategoryComponent
  },
  {
    path: 'admin/categories/:id',
    component: EditCategoryComponent
  },
  {
    path: 'admin/categories/delete/:id',
    component: DeleteCategoryComponent
  },
  {
    path: 'admin/blogposts',
    component: BlogpostListComponent
  },
  {
    path: 'admin/blogposts/add',
    component: AddBlogpostComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

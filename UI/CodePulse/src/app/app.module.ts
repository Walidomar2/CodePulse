import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './core/components/navbar/navbar.component';
import { CategoriesListComponent } from './feature/category/categories-list/categories-list.component';
import { AddCategoryComponent } from './feature/category/add-category/add-category.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { EditCategoryComponent } from './feature/category/edit-category/edit-category.component';
import { DeleteCategoryComponent } from './feature/category/delete-category/delete-category.component';
import { BlogpostListComponent } from './feature/blog-post/blogpost-list/blogpost-list.component';
import { AddBlogpostComponent } from './feature/blog-post/add-blogpost/add-blogpost.component';
import { MarkdownModule } from 'ngx-markdown';
import { EditBlogpostComponent } from './feature/blog-post/edit-blogpost/edit-blogpost.component';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    CategoriesListComponent,
    AddCategoryComponent,
    EditCategoryComponent,
    DeleteCategoryComponent,
    BlogpostListComponent,
    AddBlogpostComponent,
    EditBlogpostComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    MarkdownModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

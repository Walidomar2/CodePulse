import { Routes } from '@angular/router';
import { CategoryListComponent } from './features/category/category-list/category-list.component';
import { NavbarComponent } from './core/components/navbar/navbar.component';
import { AppComponent } from './app.component';
import { MainPageComponent } from './features/main-page/main-page.component';

export const routes: Routes = [
    {
        path: '',
        component: MainPageComponent
    },
    {
        path: 'admin/categories',
        component: CategoryListComponent
    }
];

import { Component, OnDestroy, OnInit } from '@angular/core';
import { Category } from '../models/category.model';
import { Subscription } from 'rxjs';
import { CategoryService } from '../services/category.service';
import { ActivatedRoute, Route, Router } from '@angular/router';


@Component({
  selector: 'app-delete-category',
  templateUrl: './delete-category.component.html',
  styleUrls: ['./delete-category.component.css']
})



export class DeleteCategoryComponent implements OnInit, OnDestroy {
  id: string | null = null;
  deleteCategorySubscription?: Subscription;
  paramSubscription?: Subscription;
  category?: Category;

  constructor(private route: ActivatedRoute,
    private categoryService: CategoryService,
    private router: Router) {

  }
  ngOnDestroy(): void {
    this.paramSubscription?.unsubscribe();
    this.deleteCategorySubscription?.unsubscribe();
  }


  ngOnInit(): void {
    this.paramSubscription = this.route.paramMap.subscribe({
      next: (params) => {
        this.id = params.get('id');

        if (this.id) {
          this.categoryService.getCategoryById(this.id)
            .subscribe({
              next: (response) => {
                this.category = response;
              }
            });
        }
      }
    })
  }

  onFormSubmit(): void {

    if (this.id) {
      this.deleteCategorySubscription = this.categoryService.deleteCategory(this.id)
        .subscribe({
          next: (response) => {
            this.router.navigateByUrl('/admin/categories');
          }
        });
    }

  }

}

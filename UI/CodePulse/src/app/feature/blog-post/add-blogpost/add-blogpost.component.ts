import { Component, OnDestroy, OnInit } from '@angular/core';
import { AddBlogPost } from '../models/add-blog-post.model';
import { BlogPostService } from '../services/blog-post.service';
import { Router } from '@angular/router';
import { Observable, Subscriber } from 'rxjs';
import { Subscription } from 'rxjs';
import { CategoryService } from '../../category/services/category.service';
import { Category } from '../../category/models/category.model';
import { ImageService } from 'src/app/shared/components/image-selector/image.service';

@Component({
  selector: 'app-add-blogpost',
  templateUrl: './add-blogpost.component.html',
  styleUrls: ['./add-blogpost.component.css']
})
export class AddBlogpostComponent implements OnDestroy, OnInit {
  model: AddBlogPost;
  private addBlogPostSubscribtion?: Subscription;
  categories$?: Observable<Category[]>;
  isImageSelectorVisible: boolean = false;
  imageSelectSubscricption?: Subscription;


  constructor(private blogPostService: BlogPostService,
    private router: Router,
    private categoryService: CategoryService,
    private imageService: ImageService) {

    this.model = {
      title: '',
      shortDescription: '',
      urlHandle: '',
      content: '',
      featuredImageUrl: '',
      author: '',
      isVisible: true,
      publishedDate: new Date(),
      categories: []
    }

  }

  closeImageSelector(): void {
    this.isImageSelectorVisible = false;
  }

  openImageSelector(): void {
    this.isImageSelectorVisible = true;
  }


  ngOnInit(): void {
    this.categories$ = this.categoryService.getAllCategories();

    this.imageSelectSubscricption = this.imageService.onSelectImage().subscribe({
      next: (selectedImage) => {
        if (this.model) {
          this.model.featuredImageUrl = selectedImage.url;
          this.isImageSelectorVisible = false;
        }
      }
    });
  }
  ngOnDestroy(): void {
    this.addBlogPostSubscribtion?.unsubscribe();
    this.imageSelectSubscricption?.unsubscribe();
  }

  onFormSubmit(): void {
    this.addBlogPostSubscribtion = this.blogPostService.createBlogPost(this.model)
      .subscribe({
        next: (response) => {
          this.router.navigateByUrl('/admin/blogposts');
        }
      });
  }

}

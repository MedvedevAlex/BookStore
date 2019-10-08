import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { FlexLayoutModule } from '@angular/flex-layout';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialBlockModule } from './shared/material-block-module';
import { Ng2CarouselamosModule } from 'ng2-carouselamos';
import { NavMenuComponent } from './head/nav-menu/nav-menu.component';
import { HomeComponent } from './body/home/home.component';
import { CounterComponent } from './body/counter/counter.component';
import { MainPanelComponent } from './head/main-panel/main-panel-component';
import { TitleBarComponent } from './head/title-bar/title-bar.component';
import { CategoryComponent } from './body/category/category.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    TitleBarComponent,
    MainPanelComponent,
    CategoryComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserModule,
    BrowserAnimationsModule,
    MaterialBlockModule,
    FlexLayoutModule,
    ReactiveFormsModule,
    HttpClientModule,
    Ng2CarouselamosModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'category', component: CategoryComponent }

    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

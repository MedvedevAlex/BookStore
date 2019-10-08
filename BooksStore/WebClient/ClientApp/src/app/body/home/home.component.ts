import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})



export class HomeComponent implements OnInit {
  items: Array<any> = [];
  constructor() {
    this.items = [
      { name: 'https://ndc.book24.ru/resize_cache/9658024/82aff9b7004fb1831f626fc857f53daf/iblock/332/332600fc6d027a75a5f2e99a18d5069d.jpg', book: 'Книга 1' },
      { name: 'https://cdn.book24.ru/v2/ITD000000000994236/COVER/cover3d1__w130.webp', book: 'Книга 1' },
      { name: 'https://cdn.book24.ru/v2/ASE000000000844497/COVER/cover3d1__w130.webp', book: 'Книга 1' },
      { name: 'https://cdn.book24.ru/v2/AST000000000155650/COVER/cover3d1__w130.webp', book: 'Книга 1' },
      { name: 'https://ndc.book24.ru/resize_cache/9658024/82aff9b7004fb1831f626fc857f53daf/iblock/332/332600fc6d027a75a5f2e99a18d5069d.jpg', book: 'Книга 1' },
      { name: 'https://cdn.book24.ru/v2/ITD000000000994236/COVER/cover3d1__w130.webp', book: 'Книга 1' },
      { name: 'https://cdn.book24.ru/v2/ASE000000000844497/COVER/cover3d1__w130.webp', book: 'Книга 1' },
      { name: 'https://cdn.book24.ru/v2/AST000000000155650/COVER/cover3d1__w130.webp', book: 'Книга 1' },
      { name: 'https://cdn.book24.ru/v2/ITD000000000994236/COVER/cover3d1__w130.webp', book: 'Книга 1' },
      { name: 'https://cdn.book24.ru/v2/ASE000000000844497/COVER/cover3d1__w130.webp', book: 'Книга 1' }
    ]
  }
  ngOnInit() {
    this.carusel();
  }

  carusel() {
    if (document.querySelectorAll('.imageSlider').length > 0) {
      var slide = 0,
        slides = document.querySelectorAll('.imageSlider_slide'),
        numSlides = slides.length,

        currentSlide = function () {
          var itemToShow = Math.abs(slide % numSlides);
          [].forEach.call(slides, function (el) {
            el.classList.remove('slideActive')
          });
          slides[itemToShow].classList.add('slideActive');

          resetInterval();
        },
        next = function () {
          slide++;
          currentSlide();
        },
        prev = function () {
          slide--;
          currentSlide();
        },

        resetslide = function () {
          var elm = document.querySelector('#slides > li'),
            newone = elm.cloneNode(true),
            x = elm.parentNode.replaceChild(newone, elm);
        },
        resetInterval = function () {
          clearInterval(autonext);
          autonext = setInterval(function () {
            slide++;
            currentSlide();
          }, 10000);
        },
        autonext = setInterval(function () {
          next();
        }, 10000);


      //Buttons
      document.querySelector('.nextSlide').addEventListener('click', function () {
        next();
      }, false);
      document.querySelector('.prevSlide').addEventListener('click', function () {
        prev();
      }, false);
    }
  }
}
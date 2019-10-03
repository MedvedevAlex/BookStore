import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})



export class HomeComponent implements OnInit {
  items: Array<any> = [];
  constructor(){
    this.items = [
      {name: 'https://img2.freepng.ru/20180407/xoq/kisspng-arrow-computer-icons-clip-art-right-arrow-5ac90b5b4e9110.5288946415231250833218.jpg'},
      {name: 'https://img2.freepng.ru/20180407/xoq/kisspng-arrow-computer-icons-clip-art-right-arrow-5ac90b5b4e9110.5288946415231250833218.jpg'},
      {name: 'https://img2.freepng.ru/20180407/xoq/kisspng-arrow-computer-icons-clip-art-right-arrow-5ac90b5b4e9110.5288946415231250833218.jpg'},
      {name: 'https://img2.freepng.ru/20180407/xoq/kisspng-arrow-computer-icons-clip-art-right-arrow-5ac90b5b4e9110.5288946415231250833218.jpg'},
      {name: 'https://img2.freepng.ru/20180407/xoq/kisspng-arrow-computer-icons-clip-art-right-arrow-5ac90b5b4e9110.5288946415231250833218.jpg'},
      {name: 'https://img2.freepng.ru/20180407/xoq/kisspng-arrow-computer-icons-clip-art-right-arrow-5ac90b5b4e9110.5288946415231250833218.jpg'}
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
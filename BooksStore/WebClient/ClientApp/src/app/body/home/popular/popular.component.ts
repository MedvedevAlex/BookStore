import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-popular',
  templateUrl: './popular.component.html',
  styleUrls: ['./popular.component.css']
})



export class PopularComponent implements OnInit {
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
  }

}
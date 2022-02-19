import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AniversarioDetalheComponent } from './aniversario-detalhe.component';

describe('AniversarioDetalheComponent', () => {
  let component: AniversarioDetalheComponent;
  let fixture: ComponentFixture<AniversarioDetalheComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AniversarioDetalheComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AniversarioDetalheComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

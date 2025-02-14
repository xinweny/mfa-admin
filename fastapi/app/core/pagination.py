from typing import TypeVar
from math import ceil
from fastapi import Depends
from sqlalchemy import func, select
from sqlalchemy.orm import Session
from sqlalchemy.sql.expression import Select
from sqlalchemy.ext.declarative import DeclarativeMeta
from pydantic import BaseModel, Field

from app.database import get_db

M = TypeVar('M', bound=DeclarativeMeta)

class PaginationRequest(BaseModel):
    page: int = Field(1, ge=1)
    limit: int | None = Field(None, ge=1)
    
class PaginationMetadata(BaseModel):
    current_page: int
    total_pages: int
    total_count: int
    page_size: int | None

def paginate(
    query: Select[tuple[M]],
    params: PaginationRequest = Depends(),
    db: Session = Depends(get_db),
):
    page = params.page
    limit = params.limit
    
    total_count = int(db.execute(select(func.count).select_from(query.subquery())).scalar_one())
    
    total_pages = ceil(total_count / limit) if limit is not None else 1
  
    return PaginationMetadata(
        current_page=page if page <= total_pages else total_pages,
        total_pages=total_pages,
        total_count=total_count,
        page_size=limit,
    )
